import React from 'react'
import "./AddRoom.css"
import { useEffect, useState } from 'react'
import axios from 'axios'

export default function AddRoom() {

    function SaveData() {
        let data = { name, houseId }
        axios.post('https://smartlivingapi.azurewebsites.net/api/Area', {
            name: name,
            houseId: 4
        }, {
            headers: { auth: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjdkYzAwYmU4LWEzZTQtNGU4ZC05ZjBhLTc2ZDBjN2JmZDRlOSIsIm5iZiI6MTY1ODQxMTc2MCwiZXhwIjoxNjU5MDE2NTYwLCJpYXQiOjE2NTg0MTE3NjB9.HDUhvOfj6ZxCVPirrahvk44GINAF_0c_gF3eNkkXw6o" }
        }
        ).then((response) => {
            alert("Thêm thành công !")
        })
    }
    const [name, setRoomName] = useState('')
    const [houseId, setHouseID] = useState('')
    return (
        <div className='addRoomForm'>
            <h1>Add New Room</h1>
            <label>Nhập tên phòng</label>
            <input type="text" name='name' value={name} onChange={(e) => { setRoomName(e.target.value) }} />
            <button type='button' className='submitButton' onClick={SaveData}>Save New Room</button>
        </div>
    );
}
