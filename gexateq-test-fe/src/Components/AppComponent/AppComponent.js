import React, { useState, useEffect } from 'react';
import { API } from '../../Data/Consts/Api.const.js';
import './AppComponent.css';
import TableComponent from '../Employee/TableComponent/TableComponent.js';
import DeleteComponent from '../Employee/DeleteComponent/DeleteComponent.js';
import ModalComponent from '../ModalComponent/ModalComponent.js';

const AppComponent = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [selectedItems, setSelectedItems] = useState([]);

    useEffect(() => {
        fetchData();
    }, []);
    const fetchData = async () => {
        setLoading(true);
        const url = API.employee.getAllEmployee();
        try {
            const response = await fetch(url);
            if (!response.ok) {
                console.log("THROW ERROR");
                throw new Error(response.status);
            }
            const result = await response.json();
            setData(result);
        } catch (err) {
            
            setError(err.message);
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        const refresh = () => {
            window.location.reload();
        };

        return (
            <div className='error-message'>
                <p>Error occurred, try again later</p>
                <button onClick={refresh}>Refresh</button>
            </div>
        );
    }

    return (
        <div>
            <TableComponent 
                data={data}
                selectedItems={selectedItems} 
                setSelectedItems={setSelectedItems}
            />

            <div className='buttons'>
                <ModalComponent
                    type={"Create"}
                    selectedItem={selectedItems}
                    disabled={false}
                    setError={setError}
                    fetchData={fetchData}
                    employee={data.find(employee => employee.id === selectedItems[0])}/>
                <ModalComponent
                    type={"Edit"}
                    selectedItem={selectedItems}
                    disabled={true}
                    setError={setError}
                    fetchData={fetchData}
                    employee={data.find(employee => employee.id === selectedItems[0])}/>
                <DeleteComponent 
                    selectedItems={selectedItems} 
                    setSelectedItems={setSelectedItems}
                    setError={setError}
                    fetchData={fetchData}/>
            </div>            
        </div>
    );
};

export default AppComponent;