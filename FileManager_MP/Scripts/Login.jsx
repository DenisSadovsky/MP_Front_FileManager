

class Header extends React.Component {
    render() {
        return <h2 className="txt-center">Login</h2>;
    }
}
ReactDOM.render(
    <Header />,
    document.getElementById("header")
);

class LoginForm extends React.Component {
    render() {
        return (
            <div>
                <div className="container">
                    <label className="txt-lt"><b>Username</b></label>
                    <input type="text" placeholder="info@example.com" name="Name" required />
                    <label><b>Password</b></label>
                    <input type="password" placeholder="Enter Password" name="Password" required />
                    <button type="submit">Login</button>
                    <label>
                        <input type="checkbox" checked="checked" name="remember" />
                        Remember me </label>
                </div>
            </div>
        );
    }


}
ReactDOM.render(
    <LoginForm />,
    document.getElementById("loginForm")
);

class LoginFooter extends React.Component {
    render() {
        return (
            <div className="container"/* style="background-color: #f1f1f1"*/>
                <button type="button" className="cancelbtn">Cancel</button>
                <span className="psw">Forgot <a href="#">password?</a></span>
            </div>);
    }
}
ReactDOM.render(
    <LoginFooter />,
    document.getElementById("loginFooter")
);


