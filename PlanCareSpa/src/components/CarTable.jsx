import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router';

function CarTable() {
    const [cars, setCars] = useState([]);
    const [searchText, setSearchText] = useState('');
    function searchCars(makeSearchText) {
        makeSearchText = makeSearchText?.length > 0 ? '?make=' + makeSearchText : '';
        axios.get('/api/Car' + makeSearchText)
            .then(res => setCars(res.data))
            .catch(err => console.error(err));
    }
    function handleClick() {
        searchCars(searchText);
    }
    useEffect(searchCars, []);

    return (
        <div>
            <p>
                <input type="text" placeholder="Toyota" value={searchText} onInput={e => setSearchText(e.target.value)}></input>
                <button onClick={handleClick}>Search By Make</button>
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
                        cars.map((car, i) => {
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
