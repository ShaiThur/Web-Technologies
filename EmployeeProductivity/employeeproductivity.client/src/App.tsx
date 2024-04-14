import './App.css';
import "../src/Css/mainStyles.css"
import Form from './Components/Form';
import { useState } from 'react';
import WorkZone from './Components/WorkZone'
import backgrImageForm from '../src/images/backgrimage.jpg'
import { Routes, Route } from 'react-router-dom';
import ErrorPage from "./Components/ErrorPage";
import PageForDirector from "./Components/PageForDirector";
import Tasks from "./Components/Tasks";
function App() {
    const [showWorkZone, setShowWorkZone] = useState(false)

    return (
        <div>
            <div className="backimage" style={ {backgroundImage: `url(${backgrImageForm})`}}>
                <div style={{width:`${100}%`, height:`${100}%`, display:'flex', justifyContent:'center', alignItems:'center'}}>
                    <Form/>
                </div>
            </div>
            <Routes>
                <Route index element={<Form/>} />
                <Route path="/workzone/:id" element={<WorkZone />}/>
                <Route path="/form" element={<Form />} />
                <Route path="/*" element={<ErrorPage/>}/>
            </Routes>
        </div>
    );
}

export default App;