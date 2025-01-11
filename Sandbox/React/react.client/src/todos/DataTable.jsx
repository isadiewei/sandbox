/* eslint-disable react/prop-types */
import { DataGrid } from '@mui/x-data-grid';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import { DeleteOutlined } from '@mui/icons-material';

export default function DataTable({ rows, update }) {
    const columns = [
        { field: 'todoId', headerName: 'ID', width: 70 },
        { field: 'name', headerName: 'Todo', width: 130 },
        { field: 'description', headerName: 'Description', width: 130 },
        {
            field: "action",
            headerName: "Action",
            sortable: false,
            renderCell: (params) => {
                const onClick = (e) => {
                    e.stopPropagation(); // don't select this row after clicking
                    const row = params.row.todoId;
                    console.log(row);
                    fetch(`task/delete/${row}`, {
                        method: 'GET',
                    }).then(() => {
                        update();
                    });
                };

                return (
                    <Button type="btn" onClick={e => onClick(e)}><DeleteOutlined /></Button>
                )
            }
        }
    ];

    const paginationModel = { page: 0, pageSize: 5 };

    return (
        <Paper sx={{ width: '100%' }}>
            <DataGrid
                rows={rows}
                columns={columns}
                initialState={{ pagination: { paginationModel } }}
                getRowId={(row) => row.todoId}
                pageSizeOptions={[5, 10]}
                checkboxSelection
                sx={{ border: 0 }}
            />
        </Paper>
    );
}
