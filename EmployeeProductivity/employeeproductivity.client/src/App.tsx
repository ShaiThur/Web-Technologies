import './App.css';
import "../src/Css/mainStyles.css"
import Form from './Components/Form';
import { useState } from 'react';
import WorkZone from './Components/WorkZone'
import backgrImageForm from '../src/images/backgrimage.jpg'
import { Routes, Route } from 'react-router-dom';
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
                <Route path="/workzone/:id" element={<WorkZone />} />
                <Route path="/form" element={<Form />} />
            </Routes>
        </div>
    );
}

export default App;