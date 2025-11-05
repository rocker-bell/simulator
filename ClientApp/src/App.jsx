import {Routes, Route} from "react-router-dom";
// import Structure from "./Components/Structure.jsx";
import Test from "./Components/Test.jsx"

function App() {


  return (
    <>
        <Routes>
            {/* <Route path="/" element={<Structure/>} /> */}
             <Route path="/" element={<Test/>} />
        </Routes>
    </>
  )
}

export default App
