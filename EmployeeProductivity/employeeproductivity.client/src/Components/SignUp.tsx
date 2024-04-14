import {useRef, useState} from "react";
import SelectCompany from "./SelectCompany";


const SignUp = ( {setShowSignUpForm} ) => {

    const checkDirector = useRef(null);
    const [showCompanyInput, setShowCompanyInput] = useState(false);

    const handleCheckboxChange = () => {
        setShowCompanyInput(checkDirector.current.checked);

    }


    return(
        <div className='container'>
            <h1>Sign Up</h1>
            <input type="text" placeholder='First name'/>
            <input type="text" placeholder='Last name'/>
            {showCompanyInput ? (<input type="text" placeholder={"Enter company(name, city)"}/>) : <SelectCompany/>}
            <input type="text" placeholder='Email'/>
            <input type="password" placeholder='Password'/>
            <div className={"checkbox"}>
                <input type={"checkbox"} ref={checkDirector} onChange={handleCheckboxChange}/>
                <p>I'm director</p>
            </div>
            <div className="signButton">
                <button>Sign up</button>
            </div>
            <div className="forButtonSwitch">
                <button onClick={() => setShowSignUpForm(false)} className="buttonSwitch">Or sign in?</button>
            </div>
        </div>
    )
}

export default SignUp;