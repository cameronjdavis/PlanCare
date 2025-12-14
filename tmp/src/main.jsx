import { createRoot } from 'react-dom/client'
import { BrowserRouter, Routes, Route, NavLink } from "react-router";
import './index.css'
import CarTable from './components/CarTable';
import RegoCheck from './components/RegoCheck';

createRoot(document.getElementById('root')).render(
    <BrowserRouter>
        <p><NavLink to="/">Cars in a table</NavLink></p>
        <Routes>
            <Route path="/" element={<CarTable />} />
            <Route path="/registration/:rego" element={<RegoCheck />} />
        </Routes>
    </BrowserRouter>
)
