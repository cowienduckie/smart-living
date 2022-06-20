import _ from 'lodash'
import global from '../configs/global.js'

/* store deviceId-username(Set) */
const DeviceMap = new Map()

/* store houseId-username(Set) */
const HouseMap = new Map()

/* init */
const initDeviceMap = ({ id }) => DeviceMap.set(id, new Set())
const initHouseMap = ({ id }) => HouseMap.set(id, new Set())

/* get all user */
const getAllUserOfDevice = ({ id }) => DeviceMap.get(id)
const gettAllUserOfHouse = ({ id }) => HouseMap.get(id)

/* add user  */
const addUserOfDevice = ({ id, username }) => {
    if (_.isSet(DeviceMap.get(id)))
        DeviceMap.set(id, DeviceMap.get(id).add(username))
    else {
        initDeviceMap({ id })
        return addUserOfDevice({ id, username })
    }

    console.log(global.tags.STORE, 'Add username to device map', id, username)
}

const addUserOfHouse = ({ id, username }) => {
    if (_.isSet(HouseMap.get(id)))
        HouseMap.set(id, HouseMap.get(id).add(username))
    else {
        initHouseMap({ id })
        return addUserOfHouse({ id, username })
    }

    console.log(global.tags.STORE, 'Add username to house map', id, username)
}

/* store username-wsConnection */
const UserWsMap = new Map()

const setUserWsMap = ({ username, connection }) => {
    if (username) {
        UserWsMap.set(username, connection)

        console.log(global.tags.STORE, 'Add connection to user map', username, typeof connection)
    }
}

const removeUserWsMap = ({ connection }) => {
    UserWsMap.forEach((value, key) => {
        if (value == connection) {
            UserWsMap.delete(key)

            console.log(global.tags.STORE, 'Delete connection to user map', key, typeof connection)
        }
    })
}

const getUserConnection = ({ username }) => {
    return UserWsMap.get(username)
}

/* remove username */
const removeUserOfDevice = ({ id, username }) => {
    var userSet
    if (userSet = DeviceMap.get(id)) {
        userSet.delete(username)

        console.log(global.tags.STORE, 'Remove username from device map', id, username)
    }
}

const removeUserOfHouse = ({ id, username }) => {
    var userSet
    if (userSet = HouseMap.get(id)) {
        userSet.delete(username)

        console.log(global.tags.STORE, 'Remove username from house map', id, username)
    }
}


export default {
    addUserOfDevice, getAllUserOfDevice,
    setUserWsMap, removeUserWsMap, getUserConnection,
    removeUserOfDevice, removeUserOfHouse,
    gettAllUserOfHouse, addUserOfHouse
}