import React from 'react'
import "./AddDevice.css"
import { useEffect, useState } from 'react'
import axios from 'axios'

export default function AddDevice() {

    function SaveData() {
        let data = { name, houseId }
        axios.post('https://smartlivingapi.azurewebsites.net/api/Area', {
            name: name,
            houseId: houseId
        }, {
            headers: { auth: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjdkYzAwYmU4LWEzZTQtNGU4ZC05ZjBhLTc2ZDBjN2JmZDRlOSIsIm5iZiI6MTY1ODQxMTc2MCwiZXhwIjoxNjU5MDE2NTYwLCJpYXQiOjE2NTg0MTE3NjB9.HDUhvOfj6ZxCVPirrahvk44GINAF_0c_gF3eNkkXw6o" }
        }
        ).then((response) => {
            console.log(response)
        })
    }
    const [name, setDeviceName] = useState('')
    const [houseId, setHouseID] = useState('')
    return (
        <div className='addRoomForm'>
            <h1>Add New Device</h1>
            <label>Chọn thiết bị :</label>
            <select id='deviceName' >
                <option value="1">Điều hoà</option>
                <option value="1">Đèn</option>
                <option value="1">Quạt</option>
                <option value="1">Tủ lạnh</option>
                <option value="1">Máy sưởi</option>
                <option value="1">Máy giặt</option>
                <option value="1">Wifi</option>
                <option value="1">Máy pha cà phê</option>
                <option value="1">Máy rửa bát</option>
                <option value="1">Máy hút bụi</option>
            </select>
            <label>Nhập ID nhà</label>
            <input type="text" name='name' value={houseId} onChange={(e) => { setHouseID(e.target.value) }} />
            <label>Chọn Phòng :</label>
            <select id='roomName' >
                <option value="1">Living Room</option>
                <option value="1">Bedroom</option>
                <option value="1">Kitchen</option>
                <option value="1">Bathroom</option>
                <option value="1">StudyRoom</option>
                <option value="1">Dining Room</option>
            </select>
            <button type='button' className='button button1' onClick={SaveData}>Save New Device</button>
        </div>
    );
}
