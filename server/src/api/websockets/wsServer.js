import { server as WebSocketServer } from 'websocket'
import global from '../configs/global.js'
import moment from 'moment'
import wsHandle from './wsHandle.js'
import store from '../store/store.js'

const TAG = global.tags.WS

export const bindHttpServer = (httpServer) => {
    const wsServer = new WebSocketServer({
        httpServer,
        // You should not use autoAcceptConnections for production
        // applications, as it defeats all standard cross-origin protection
        // facilities built into the protocol and the browser.  You should
        // *always* verify the connection's origin and decide whether or not
        // to accept it.
        autoAcceptConnections: false
    })

    function originIsAllowed(origin) {
        // put logic here to detect whether the specified origin is allowed.
        return true
    }

    wsServer.on('connect', connection => console.log(TAG, 'New socket connection'))

    wsServer.on('request', function (request) {
        if (!originIsAllowed(request.origin) || !request.resource.startsWith('/ws')) {
            // Make sure we only accept requests from an allowed origin
            request.reject()
            console.log(TAG, (new Date()) + ' Connection from origin ' + request.origin + ' rejected.')
            return
        }

        var connection = request.accept(null, request.origin)

        console.log(TAG, moment(Date.now()).format('YYYY-MM-DD HH:mm:ss') + ' Connection accepted for', request.remoteAddress)

        console.log(TAG, 'Resource:', request.resource)

        connection.on('message', function (message) {
            if (message.type === 'utf8') {
                console.log(TAG)
                console.log('===========================================')
                console.log('WS Received Message: ' + message.utf8Data)
                // connection.sendUTF(message.utf8Data)

                /* parsing to json */
                var data

                try {
                    data = JSON.parse(message.utf8Data)
                } catch (error) {
                    connection.sendUTF(JSON.stringify(
                        {
                            'message': "Try use json",
                            'hint': "It must like this one"
                        }
                    ))

                    return console.error(TAG, error)
                }

                if (data.type == 'login') {
                    if (wsHandle.loginHandler({ connection, 'message': data })) {
                        console.log(TAG, 'User login through ws', data.username)

                        connection.sendUTF(JSON.stringify({
                            'errorCode': undefined,
                            'message': "Welcome user ".concat(data.username)
                        }))
                    } else
                        connection.sendUTF(JSON.stringify({
                            'errorCode': 403,
                            'message': "Login failed"
                        }))
                } else if (data.type == 'command') {
                    if (wsHandle.commandHandler({ 'message': data, connection })) {
                        connection.sendUTF(JSON.stringify({
                            'errorCode': undefined,
                            'message': "Sent command successfully"
                        }))
                    } else {
                        connection.sendUTF(JSON.stringify({
                            errorCode: 403,
                            message: "Invalid device id"
                        }))
                    }
                } else connection.sendUTF(JSON.stringify({
                    message: "Not supported message"
                }))
            }
            else if (message.type === 'binary') {
                console.log(TAG)
                console.log('===========================================')
                console.log('Received Binary Message of ' + message.binaryData.length + ' bytes')
                connection.sendBytes(message.binaryData)
            }
        })

        connection.on('close', function (reasonCode, description) {
            console.log(TAG, moment(Date.now()).format('YYYY-MM-DD HH:mm:ss') + ' Peer ' + connection.remoteAddress + ' disconnected.')
            
            wsHandle.closeHandler({ connection })
        })
    })
}

