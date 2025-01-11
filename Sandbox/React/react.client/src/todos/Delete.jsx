import Button from '@mui/material/Button';
import { DeleteOutlined } from '@mui/icons-material';

export default function Delete({ event, updated }) {
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
        <Button type="btn" onClick={handleDeleteClick(todoId)}><DeleteOutlined /></Button>
    )
}