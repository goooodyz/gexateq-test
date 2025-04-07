import React, { useState } from 'react';
import { useForm } from "react-hook-form"
import { ErrorMessage } from "@hookform/error-message";
import { API } from '../../../Data/Consts/Api.const.js';

function CreateComponent({setError, closeModal}) {
    const [loading, setLoading] = useState(false);

    const {
        register,
        formState: { errors, isDirty },
        handleSubmit
    } = useForm({
        criteriaMode: "all",
    });

    const onSubmit = async (data) => {
        setLoading(true);
        try {
            data.Age = data.Age === "" ? null : data.Age;
            
            const response = await fetch(API.employee.createEmployee(), {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    ...data
                })
            });

            if (!response.ok) {
                throw new Error(response.status);
            }
        } catch (err) {
            setError(err.message);
        }
        finally {
            setLoading(false);
            closeModal(true);
        }
    }

    if (loading) {
        return <div>Loading...</div>;
    }

    return (
        <div>
            <form onSubmit={handleSubmit(onSubmit)}>
                <h1>*First name</h1>
                <input
                    {...register("FirstName", {
                        required: "Firs name is required"
                    })}
                />
                <ErrorMessage errors={errors} name="FirstName" as="p" />

                <h1>*Second name</h1>
                <input
                    {...register("LastName", {
                        required: "Second name is required"
                    })}
                />
                <ErrorMessage errors={errors} name="LastName" as="p" />

                <h1>*Gender</h1>
                <select
                     {...register("Gender")}
                >
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                    <option value="Other">Other</option>
                </select>

                <h1>Age</h1>
                <input
                    {...register("Age", {
                        pattern: {
                            value: /^$|^(?:1[8-9]|[2-9][0-9]|100)$/,
                            message: "Your age must be between 18 and 100 years old"
                        },
                    })}
                />
                <ErrorMessage errors={errors} name="Age" as="p" />

                <div className='close-but'>
                    <button disabled={!isDirty} type="submit">Create</button>
                    <button onClick={() => closeModal(false)} >Close</button>
                </div>
                
            </form>
        </div>
    );
}

export default CreateComponent;