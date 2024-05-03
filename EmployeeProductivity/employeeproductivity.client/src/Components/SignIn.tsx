import axios from "axios";
import {useRef, useState} from "react";
import {Link, useNavigate} from "react-router-dom";
import { User } from "../Entites/User.interface";
import { error } from "console";

interface LoginUser{
    email: string
    password: string
}


const SignIn = ( {setShowSignUpForm} : {setShowSignUpForm: (show: boolean) => void} ) => {

    const inputEmail = useRef(null);
    const inputPassword = useRef(null);
    const typeOfUser = "director";
    const selectedOption = "tasks";
    const [newUser] = useState<LoginUser>({
        email: "",
        password: "",
    })

    const navigate = useNavigate();

    const Authorization = async() =>{
        const response = await axios.request({
            url: "http://localhost:5000/api/User/AuthorizeUser",
            method: "post",
            data: {
                email: inputEmail.current.value,
                password: inputPassword.current.value
            },
        })
        localStorage.setItem('accessToken',response.data.accessToken);
    }

    const OpenWorkZone = () => {
        const id : string = `${inputEmail.current.value};${typeOfUser}`
        if(inputEmail.current.value != "" && inputPassword.current.value != ""){
            Authorization().then(() =>{
                navigate(`/workzone`);
                sessionStorage.setItem('userEmail', inputEmail.current.value);
            }).catch(() => {
                navigate(`/error`)
            });
        }
        else{
            window.alert('Enter email and password');
        }
    }

    return(
        <div className='container'>
            <h1>Sign In</h1>
            <input type="text" placeholder='Email' ref={inputEmail}/>
            <input type="password" placeholder='Password' ref={inputPassword}/>
            <div className="remindPass">
                <a href="">Forgot password?</a>
            </div>
            <div className="signButton signInButton">
                <button onClick={() => OpenWorkZone()}>Sign in</button>
            </div>
            <div className="forButtonSwitch">
                <button onClick={() => setShowSignUpForm(true)} className="buttonSwitch">Or sign up?</button>
            </div>
        </div>
    )
}

export default SignIn;