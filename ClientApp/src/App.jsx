import {Routes, Route} from "react-router-dom";
// import Structure from "./Components/Structure.jsx";
import Test from "./Components/Test.jsx"
import BlockchainChain from "./Components/Structure.jsx";
function App() {


  return (
    <>
        <Routes>
            {/* <Route path="/" element={<Structure/>} /> */}
             <Route path="/" element={<Test/>} />
             <Route path="/blockchaine_data" element={<BlockchainChain />} />
        </Routes>
    </>
  )
}

export default App
