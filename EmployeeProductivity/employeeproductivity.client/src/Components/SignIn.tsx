import {useRef} from "react";
import {Link, useNavigate} from "react-router-dom";


const SignIn = ( {setShowSignUpForm} : {setShowSignUpForm: (show: boolean) => void} ) => {

    const inputEmail = useRef(null);
    const inputPassword = useRef(null);

    const navigate = useNavigate();

    const OpenWorkZone = (id) => {
        if(inputEmail.current.value != "" && inputPassword.current.value != ""){
            navigate(`/workzone/${id}`);
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
            <div className="signInButton signInButton1">
                <button onClick={() => OpenWorkZone(inputEmail.current.value)}>Sign in</button>
            </div>
            <div className="forButtonSwitch">
                <button onClick={() => setShowSignUpForm(true)} className="buttonSwitch">Or sign up?</button>
            </div>
        </div>
    )
}

export default SignIn;