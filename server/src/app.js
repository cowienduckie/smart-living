import apiServer from './api/index.js'
import global from './configs/global.js'
import { createServer } from 'http'
// import { closeDb } from './utils/mongodb.js'
// import { bindHttpServer } from './wsServer/wsServer.js'

async function startServer() {  
    const server = createServer()
        .on('request', apiServer)
        .on('close', closeDb)
        .on('error', (error) => {
            console.error(error);
            process.exit(1);
        })
    
    /* ws */
    bindHttpServer(server)
    
    server.listen(global.PORT, global.BASE_URL, function () {
        console.log(
            '[SERVER]', (new Date()) + ' Server is listening on port', global.PORT
            );
    })
}

