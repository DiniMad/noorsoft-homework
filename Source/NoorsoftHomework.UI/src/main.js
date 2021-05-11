import {createApp} from "vue"
import App from "./App.vue"
import {library} from "@fortawesome/fontawesome-svg-core"
import {
    faBirthdayCake,
    faBriefcase,
    faStar,
    faPlus,
    faEdit,
    faTrash,
    faAngleLeft,
    faAngleRight,
    faSortAmountDownAlt,
    faSortAmountUp
} from "@fortawesome/free-solid-svg-icons"
import {FontAwesomeIcon} from "@fortawesome/vue-fontawesome"

import "bootstrap/dist/css/bootstrap.css";

library.add(faBirthdayCake)
library.add(faBriefcase)
library.add(faStar)
library.add(faPlus)
library.add(faEdit)
library.add(faTrash)
library.add(faAngleLeft)
library.add(faAngleRight)
library.add(faSortAmountDownAlt)
library.add(faSortAmountUp)

createApp(App)
    .component("font-awesome-icon", FontAwesomeIcon)
    .mount("#app")
