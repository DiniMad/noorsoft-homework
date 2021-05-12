const apiRoot = "https://localhost:5001"
const api = {
    getEmployees: `${apiRoot}/employee`,
    deleteEmployee: (id) => `${apiRoot}/employee/${id}`
}
export default {
    api
}