import React, { useEffect, useState } from 'react';
import axios from 'axios';

function CarTable() {
    const [data, setData] = useState([
    ]);
    useEffect(() => {
        axios.get('/api/Car')
            .then(res => setData(res.data))
            .catch(err => console.error(err));
    }, [])

    return (
        <table>
            <thead>
                <tr>
                    <td>ID</td>
                    <td>Make</td>
                    <td>Rego</td>
                    <td>Registered Until</td>
                </tr>
            </thead>
            <tbody>
                {
                    data.map((car, i) => {
                        return <tr key={i}>
                            <td>{car.id}</td>
                            <td>{car.make}</td>
                            <td className="rego">{car.registration}</td>
                            <td>{car.registeredUntil}</td>
                        </tr>
                    })
                }
            </tbody>
        </table>
    )
}

export default CarTable;
