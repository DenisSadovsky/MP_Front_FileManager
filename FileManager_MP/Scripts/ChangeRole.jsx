

class ChRoleHeader extends React.Component {
    render() {
        return <h2 className="txt-center">Login</h2>;
    }
}
ReactDOM.render(
    <ChRoleHeader />,
    document.getElementById("chRoleHeader")
);

class ChRoleForm extends React.Component {
    render() {
        return (
            <div>
                <div className="container">
                    <label><b>Username</b></label>
                    <input type="text" placeholder="info@example.com" name="Name" required />
                    <label><b>Role</b></label>
                    <input type="text" placeholder="Enter Role(ex. admin or user)" name="Role" required />
                    <button type="submit">Change</button>
                </div>
            </div>
        );
    }

}
ReactDOM.render(
    <ChRoleForm />,
    document.getElementById("chRoleForm")
);

