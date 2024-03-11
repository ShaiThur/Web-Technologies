import SignIn from './SignIn';
import { useState } from 'react';
import "../Css/form.css"
import SignUp from './SignUp';

const Form = ( { setShowWorkZone} : {setShowWorkZone:() => void} ) => {
    const [showSignUpForm, setShowSignUpForm] = useState(false);
    const myHeight = showSignUpForm ? 720 : 550;
    const myTop = showSignUpForm ? 140 : 210;

    return(
        <div className='mainView' style={{height: myHeight, top:myTop}}>
            {showSignUpForm ? <SignUp setShowSignUpForm={setShowSignUpForm}/> : <SignIn setShowSignUpForm={setShowSignUpForm} setShowWorkZone={setShowWorkZone}/>}
        </div>
    );
};

export default Form;
