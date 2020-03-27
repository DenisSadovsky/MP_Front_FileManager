

class UserHeader extends React.Component {
    render() {
        return <h2 className="txt-center">File Manager</h2>;
    }
}
ReactDOM.render(
    <UserHeader />,
    document.getElementById("userHeader")
);

class UserForm extends React.Component {
    render() {
        return (
            <div>
                <div className="container">
                    <label><b>Path</b></label>
                    <input type="text" placeholder="C:\123" name="Path" required />
                    <button type="submit" value="Open" name="open" className="createButton">Open</button>
                </div>
            </div>
        );
    }

}
ReactDOM.render(
    <UserForm />,
    document.getElementById("userForm")
);