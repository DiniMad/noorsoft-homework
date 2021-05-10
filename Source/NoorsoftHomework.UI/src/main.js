import {createApp} from "vue"
import App from "./App.vue"
import {library} from "@fortawesome/fontawesome-svg-core"
import {faBirthdayCake, faBriefcase, faStar, faPlus, faEdit, faTrash} from "@fortawesome/free-solid-svg-icons"
import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome"

import "bootstrap/dist/css/bootstrap.css";

library.add(faBirthdayCake)
library.add(faBriefcase)
library.add(faStar)
library.add(faPlus)
library.add(faEdit)
library.add(faTrash)

createApp(App)
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount("#app")
