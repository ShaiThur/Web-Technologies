import SignIn from './SignIn';
import { useState } from 'react';
import "../Css/form.css"
import SignUp from './SignUp';

const Form = ( ) => {
    const [showSignUpForm, setShowSignUpForm] = useState(false);
    const myHeight = showSignUpForm ? 670 : 550;
    const myTop = showSignUpForm ? 140 : 210;

    return(
        <div className='mainView' style={{height: myHeight, top:myTop}}>
            {showSignUpForm ? <SignUp setShowSignUpForm={setShowSignUpForm}/> : <SignIn setShowSignUpForm={setShowSignUpForm}/>}
        </div>
    );
};

export default Form;
