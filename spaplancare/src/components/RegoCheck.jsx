import React, { useEffect } from 'react';
import { useParams } from "react-router";
import * as signalR from '@microsoft/signalr';
function RegoCheck() {
    let rego = useParams().rego;
    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5141/regoHub?rego=" + rego, {
                skipNegotiation: true,
                transport: signalR.HttpTransportType.WebSockets
            })
            .build();

        connection.start()
            .catch(err => console.log('Error while starting connection: ' + err));

        connection.on("ReceiveMessage", function (user, message) {
            console.log(user, message);
        });
    }, []);

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
                    <td className="rego">{ rego }</td>
                    <td>TODO</td>
                </tr>
            </tbody>
        </table>
    );
}

export default RegoCheck;
