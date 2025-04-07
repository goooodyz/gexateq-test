import React from 'react';
import { API } from '../../../Data/Consts/Api.const.js';

const DeleteComponent = ({ selectedItems, setSelectedItems, setError, fetchData}) => {    
    const HandleDelete = async () => {
            const confirmed = window.confirm(
                `Are you sure you want to delete selected employees?`
            );
        
            if (!confirmed) {
                return;
            }
    
            try {
                await Promise.all(
                    selectedItems.map(item =>
                        fetch(API.employee.deleteEmployee(item), {
                            method: 'DELETE',
                        })
                    )
                );
                
                setSelectedItems([]);
                fetchData();
            } catch (err) {
                setError(err.message);
            }
        };

    return (
        <button disabled={selectedItems.length === 0} onClick={HandleDelete}>Delete</button>
    );
};

export default DeleteComponent;