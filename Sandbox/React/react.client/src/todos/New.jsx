import './New.css';
import { useState } from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { AddOutlined } from '@mui/icons-material';

import { styled } from '@mui/material/styles';

const StyledButton = styled(Button)(({ theme }) => ({
    //color: 'red'
}));
const StyledTextField = styled(TextField)({
    input: {
        color: '#E0E3E7'
    },
    '& label.Mui-focused': {
        color: '#A0AAB4',
    },
    '& .MuiInput-underline:after': {
        borderBottomColor: '#B2BAC2',
    },
    '.MuiFormLabel-root': {
        color: '#E0E3E7'
    },
    '& .MuiOutlinedInput-root': {
        '& fieldset': {
            borderColor: '#E0E3E7',
        },
        '&:hover fieldset': {
            borderColor: '#B2BAC2',
        },
        '&.Mui-focused fieldset': {
            borderColor: '#6F7E8C',
        },
    },
});


export default function New({ updated }) {
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");

    function handleNameChange(e) {
        setName(e.target.value);
    }

    function handleDescriptionChange(e) {
        setDescription(e.target.value);
    }

    function handleAddClick() {
        const body = JSON.stringify({
            name: name,
            description: description
        });

        fetch('task', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body
        }).then(() => {
            updated();
        });
    }

    return (
        <div style={{ flexDirection: "row", justifyContent: "space-between" }} >
            <StyledTextField
                value={name}
                onChange={handleNameChange}
                label="Task"
                className="styled-input"
                fontColor="red"
            ></StyledTextField>
            <StyledTextField
                value={description}
                onChange={handleDescriptionChange}
                label="Description"
                className="styled-input"
                fontColor="red"
            ></StyledTextField>
            <StyledButton
                onClick={() => handleAddClick()}
                className="styled-button"
            >
                <AddOutlined></AddOutlined>
            </StyledButton>
        </div>
    );
}

