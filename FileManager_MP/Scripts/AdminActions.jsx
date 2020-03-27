class AdminHeader extends React.Component {
    render() {
        return <h2 className="txt-center">File Manager</h2>;
    }
}
ReactDOM.render(
    <AdminHeader />,
    document.getElementById("adminHeader")
);

class AdminForm extends React.Component {
    render() {
        return (
            <div className="container">
                    <label><b>Path</b></label>
                    <input type="text" placeholder="C:\123" name="Path" required />
                    <button type="submit" value="Open" name="open" className="createButton">Open</button>
                    <button type="submit" value="CreateFile" name="createFile" className="createButton">Create File</button>
                    <button type="submit" value="CreateDirectory" name="createDirectory" className="createButton">Create Directory</button>
                    <button type="submit" value="Delete" name="delete" className="createButton">Delete</button>
                </div>
            );
    }
}
ReactDOM.render(
    <AdminForm />,
    document.getElementById("adminForm")
);

