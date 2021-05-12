const apiRoot = "https://localhost:5001"
const api = {
    getEmployees: () => `${apiRoot}/employee`,
    deleteEmployee: (id) => `${apiRoot}/employee/${id}`,
    updateEmployee: (id) => `${apiRoot}/employee/${id}`,
    createEmployee: () => `${apiRoot}/employee`,
}
export default {
    api
}