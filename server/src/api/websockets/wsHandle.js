import global from '../app/global.js'
import store from '../store/store.js'
import authUtils from '../utils/authUtils.js'
import bridge from '../utils/wsMqttBridge/bridge.js'

const loginHandler = ({ message, connection }) => {
    const token = message.token

    if (!authUtils.validateToken(token)) return undefined

    const username = message.username

    store.setUserWsMap({ username, connection })

    return true
}

const closeHandler = ({ connection }) => {
    store.removeUserWsMap({ connection })
}

const commandHandler = ({ message, connection }) => {
    const username = message.username

    if (store.getUserConnection({ username }) == connection) {
        const deviceId = message.deviceId

        try {
            if (store.getAllUserOfDevice({ 'id': deviceId }).has(username)) {
                bridge.commandHandle({ 'command': message })

                return true
            } else throw new Error(`User ${message.username} not has this device ${deviceId}`)
        } catch (error) {
            console.error(global.tags.WS, error)

            return undefined
        }

    }

    return undefined
}

export default { loginHandler, closeHandler, commandHandler }