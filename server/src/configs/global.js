const BASE_URL = '0.0.0.0'
const PORT = process.env.PORT || 4000
const BROKER = ""

const tags = {
    DATABASE: '[Database]',
    WS: '[WS]',
    API: '[API]',
    POST: '[POST]',
    GET: '[GET]',
    BROKER: '[BROKER]',
    STORE: '[STORE]',
}

export default {
    PORT, BASE_URL, tags, BROKER
}