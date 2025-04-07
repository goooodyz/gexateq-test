import React from 'react';
import './TableComponent.css';

const TableComponent = ({data, selectedItems, setSelectedItems}) => {    
    const selectItem = (id) => {
        if (selectedItems.includes(id)) {
            setSelectedItems(selectedItems.filter(item => item !== id));
        } else {
            setSelectedItems([...selectedItems, id]);
        }
        
        console.log("Item ---", selectedItems);
    };

    return (
        <div className="table-container">
            <table className="scrollable-table">
                <thead>
                    <tr>
                        <th>№</th>
                        <th>Full name</th>
                        <th>Gender</th>
                        <th>Age</th>
                    </tr>
                </thead>

                <tbody>
                    {data.map((item, index) => (
                    <tr 
                        key={index}
                        className={selectedItems.includes(item.id) ? 'selected-row' : index % 2 === 0 ? 'even-row' : 'odd-row'}
                        onClick={() => selectItem(item.id)}
                    >
                        <td>{index + 1}</td>
                        <td>{item.firstName} {item.lastName}</td>
                        <td>{item.gender}</td>
                        <td>{item.age} {item.age ? "years" : ""}</td>
                    </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default TableComponent;