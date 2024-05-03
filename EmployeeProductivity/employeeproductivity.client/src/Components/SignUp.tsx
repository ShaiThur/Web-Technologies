import {useRef, useState} from "react";
import SelectCompany from "./SelectCompany";
import { User } from "../Entites/User.interface";
import axios from "axios";


const SignUp = ( {setShowSignUpForm} ) => {

    const checkDirector = useRef(null);
    const [showCompanyInput, setShowCompanyInput] = useState(false);
    const inputFirstName = useRef(null);
    const inputLastName = useRef(null);
    const inputEmail = useRef(null);
    const inputPassword = useRef(null);

    const [newUser] = useState<User>({
        firstname: "",
        lastname: "",
        email: "",
        password: "",
    });

    const RegistrationNewUser = () =>{
        newUser.email = inputEmail.current.value;
        newUser.firstname = inputFirstName.current.value;
        newUser.lastname = inputLastName.current.value;
        newUser.password = inputPassword.current.value;
        console.log(newUser)
        RegisterNewUserPost();
    }

    const RegisterNewUserPost = async () => {
        const response = await axios.request({
            url: "http://localhost:5000/api/User/RegisterUser",
            method: "post",
            headers: {
                'Content-Type': 'application/json'
            },
            data: newUser
        });
        console.log(response);
    };

    const Registration = () =>{
        if(inputFirstName.current.value && inputLastName.current.value && inputEmail.current.value && inputPassword.current.value){
            RegistrationNewUser();
        }else{
            alert(`Fill all forms`)
        }
    }

    return(
        <div className='container'>
            <h1>Sign Up</h1>
            <input type="text" placeholder='First name' ref={inputFirstName}/>
            <input type="text" placeholder='Last name' ref={inputLastName}/>
            <input type="text" placeholder='Email' ref={inputEmail}/>
            <input type="password" placeholder='Password' ref={inputPassword}/>
            <div className="signButton">
                <button onClick={Registration}>Sign up</button>
            </div>
            <div className="forButtonSwitch">
                <button onClick={() => setShowSignUpForm(false)} className="buttonSwitch">Or sign in?</button>
            </div>
        </div>
    )
}

export default SignUp;