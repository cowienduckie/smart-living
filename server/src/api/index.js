import express from 'express'
import router from './routes/index.js'
import cors from 'cors'

const app = express()

app.use(cors())
app.use('/', express.static('public'))
app.use('/api/v1', router)

app.use('/*', function (req, res, next) {
    res.send('More APIs are under way')
})

export default app

