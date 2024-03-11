const SignIn = ( {setShowSignUpForm, setShowWorkZone} : {setShowSignUpForm: (show: boolean) => void, setShowWorkZone:(show : boolean)=>void} ) => {

    return(
        <div className='container'>
            <h1>Sign In</h1>
            <input type="text" placeholder='Email'/>
            <input type="password" placeholder='Password'/>
            <div className="remindPass">
                <a href="">Forgot password?</a>
            </div>
            <div className="signInButton signInButton1">
                <button onClick={() => setShowWorkZone(true)}>Sign in</button>
            </div>
            <div className="forButtonSwitch">
                <button onClick={() => setShowSignUpForm(true)} className="buttonSwitch">Or sign up?</button>
            </div>
        </div>
    )
}

export default SignIn;