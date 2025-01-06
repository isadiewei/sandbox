import { useEffect, useState } from 'react';
import './App.css';
import New from './todos/New';
import Delete from './todos/Delete';

function App() {
    const [todos, setTodos] = useState();

    useEffect(() => {
        populate();
    }, []);

    const contents = todos === undefined
        ? <p><em>Loading...</em></p>
        : <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {todos.map(todo =>
                    <tr key={todo.taskId}>
                        <td>{todo.name}</td>
                        <td>{todo.description}</td>
                        <td><Delete updated={populate} todoId={todo.taskId} /></td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tableLabel">Todos</h1>
            <p>A list of tasks to complete.</p>
            <New updated={populate} />
            <hr />
            {contents}
        </div>
    );
    
    async function populate() {
        const response = await fetch('task');
        if (response.ok) {
            const data = await response.json();
            setTodos(data);
        }
    }

    function removeTodo(taskId) {
    //    data = todos;
    //    const index = array.indexOf(x => x.);
    //    if (index > -1) { // only splice array when item is found
    //        array.splice(index, 1); // 2nd parameter means remove one item only
    //    }
        console.log('todo is supposed to be removed');
    }
}

export default App;