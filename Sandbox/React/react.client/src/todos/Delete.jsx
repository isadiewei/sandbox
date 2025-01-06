export default function Delete({ todoId, updated }) {
    function handleDeleteClick(id) {
        return function () {
            fetch(`task/delete/${id}`, {
                method: 'GET',
            }).then(() => {
                updated();
            });
        }
    }

    return (
        <button type="btn" onClick={handleDeleteClick(todoId)}>X</button>
    )
}