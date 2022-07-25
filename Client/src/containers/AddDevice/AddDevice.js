import React from 'react'
import "./AddDevice.css"
import { useEffect, useState } from 'react'
import axios from 'axios'

export default function AddDevice() {

    function SaveData() {
        axios.post('https://smartlivingapi.azurewebsites.net/api/Device', {
            name: name,
            deviceTypeId: document.getElementById('deviceName').value,
            houseId: 4,
            areaId: document.getElementById('roomName').value,
            params: "string",
            isActive: true,
        }, {
            headers: { auth: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjdkYzAwYmU4LWEzZTQtNGU4ZC05ZjBhLTc2ZDBjN2JmZDRlOSIsIm5iZiI6MTY1ODQxMTc2MCwiZXhwIjoxNjU5MDE2NTYwLCJpYXQiOjE2NTg0MTE3NjB9.HDUhvOfj6ZxCVPirrahvk44GINAF_0c_gF3eNkkXw6o" }
        }
        ).then((response) => {
            alert("Thêm thành công !")
        })
    }
    const [name, setDeviceName] = useState('')
    return (
        <div className='addRoomForm'>
            <h1>Add New Device</h1>
            <label>Tên thiết bị :</label>
            <input type="text" name='name' value={name} onChange={(e) => { setDeviceName(e.target.value) }} />
            <label>Chọn loại thiết bị :</label>
            <select id='deviceName' >
                <option value="1">Air Conditional</option>
                <option value="2">Light</option>
                <option value="9">Fan</option>
                <option value="10">Heater</option>
                <option value="11">Cloth Washer</option>
                <option value="12">Wifi</option>
                <option value="15">Coffee Machine</option>
                <option value="16">Dish Washer</option>
                <option value="17">Claner</option>
                <option value="4">Television</option>
            </select>
            <label>Chọn Phòng :</label>
            <select id='roomName' >
                <option value="4">Living Room</option>
                <option value="3">Bedroom</option>
                <option value="7">Kitchen</option>
                <option value="2">Bathroom</option>
                <option value="5">StudyRoom</option>
                <option value="6">Dining Room</option>
                <option value="27">New Room 25/7</option>
            </select>
            <button type='button' className='submitButton' onClick={SaveData}>Save New Device</button>
        </div>
    );
}
