import "../Styles/Structure.css"
import {Link} from "react-router-dom";
const Structure = () => {
    return (
            <>
                <div className="structure_wrapper">
                    <h2>Structure page</h2>
                    <Link to="/Test">test</Link>
                </div>
            </>
    )
}

export default Structure