import React, { useEffect, useState } from 'react';
import { useParams } from "react-router";
import * as signalR from '@microsoft/signalr';
function RegoCheck() {
    let rego = useParams().rego;
    const [car, setCar] = useState();
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5141/regoHub", {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets
            })
            .build();

        connection.start()
            .catch(err => console.log('Error while starting connection: ' + err));

        connection.on("ReceiveMessage", function (message) {
            const cars = JSON.parse(message);
            setCar(cars.find(c => c.Registration == rego));
        });
    }, [rego]);

    return (
        <table>
            <thead>
                <tr>
                    <td>Rego</td>
                    <td>Rego Status</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td className="rego">{rego}</td>
                    <td className={car?.RegistrationStatus}>{car?.RegistrationStatus ?? 'No matching record'}</td>
                </tr>
            </tbody>
        </table>
    );
}

export default RegoCheck;
