import './App.css';
import "../src/Css/mainStyles.css"
import Form from './Components/Form';
import { useState } from 'react';
import WorkZone from './Components/WorkZone'
import backgrImageForm from '../src/images/backgrimage.jpg'
import backgrImageMain from '../src/images/workzone_backgrimage.jpg'
function App() {
    const [showWorkZone, setShowWorkZone] = useState(false)

    return (
        <div>
            <div className="backimage" style={ showWorkZone ? {backgroundImage: `url(${backgrImageMain})`} : {backgroundImage: `url(${backgrImageForm})`}}>
                <div style={{width:`${100}%`, height:`${100}%`, display:'flex', justifyContent:'center', alignItems:'center'}}>
                    {showWorkZone ? <WorkZone/> : <Form setShowWorkZone={setShowWorkZone}/>}
                </div>
            </div>
        </div>
    );
}

export default App;