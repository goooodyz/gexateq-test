export const API = {
    defaultUrl: 'https://localhost:7007/api/',

    employee: {
        getAllEmployee: () => `${API.defaultUrl}employee/all`,
        getEmployee: (id) => `${API.defaultUrl}employee/${id}`,
        createEmployee: () => `${API.defaultUrl}employee`,
        updateEmployee: () => `${API.defaultUrl}employee`,
        deleteEmployee: (id) => `${API.defaultUrl}employee/${id}`,
    },
}