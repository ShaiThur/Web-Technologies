

const SignUp = ( {setShowSignUpForm} ) => {


    return(
        <div className='container'>
            <h1>Sign Up</h1>
            <input type="text" placeholder='First name'/>
            <input type="text" placeholder='Middle name'/>
            <input type="text" placeholder='Last name'/>
            <input type="text" placeholder='Email'/>
            <input type="password" placeholder='Password'/>
            <div className="signInButton">
                <button>Sign in</button>
            </div>
            <div className="forButtonSwitch">
                <button onClick={() => setShowSignUpForm(false)} className="buttonSwitch">Or sign up?</button>
            </div>
        </div>
    )
}

export default SignUp;