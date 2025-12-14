import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router';

function CarTable() {
    const [data, setData] = useState([]);
    const [searchText, setSearchText] = useState('');
    useEffect(() => {
        axios.get('/api/Car')
            .then(res => setData(res.data))
            .catch(err => console.error(err));
    }, [])

    function handleSearch() {
        axios.get('/api/Car?make=' + searchText)
            .then(res => setData(res.data))
            .catch(err => console.error(err));
    }

    return (
        <div>
            <p>
                <input type="text" placeholder="Toyota" value={searchText} onInput={e => setSearchText(e.target.value)}></input>
                <button onClick={handleSearch}>Search By Make</button>
            </p>
            <table>
                <thead>
                    <tr>
                        <td>ID</td>
                        <td>Make</td>
                        <td>Rego</td>
                        <td>Registered Until</td>
                        <td></td>
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
                                <td><Link to={{
                                    pathname: "/registration/" + car.registration
                                }}>See Rego Status</Link></td>
                            </tr>
                        })
                    }
                </tbody>
            </table>
        </div>
    )
}

export default CarTable;
