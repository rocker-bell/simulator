// import React, { useEffect, useState } from "react";

// const BlockchainChain = () => {
//   const [chain, setChain] = useState([]);
//   const [loading, setLoading] = useState(true);

//   const API_URL = import.meta.env.VITE_API_URL || "http://localhost:5000";

//   useEffect(() => {
//     fetch("/api/blockchain/chain")
//       .then((res) => {
//         if (!res.ok) throw new Error("Failed to fetch blockchain");
//         return res.json();
//       })
//       .then((data) => {
//         setChain(data);
//         setLoading(false);
//       })
//       .catch((err) => {
//         console.error("Error fetching blockchain:", err);
//         setLoading(false);
//       });
//   }, []);

//   if (loading) return <p>Loading blockchain...</p>;
//   if (!chain || chain.length === 0) return <p>No blockchain data found.</p>;

//   return (
//     <div>
//       <h2>Blockchain</h2>
//       {chain.map((block, index) => (
//         <div key={index} style={{ border: "1px solid #ccc", margin: "10px", padding: "10px" }}>
//           <p><strong>Index:</strong> {block.Index}</p>
//           <p><strong>Timestamp:</strong> {block.Timestamp}</p>
//           <p><strong>Previous Hash:</strong> {block.PreviousHash}</p>
//           <p><strong>Hash:</strong> {block.Hash}</p>
//           <p><strong>Transactions:</strong></p>
//           <ul>
//             {block.Transactions.map((tx, i) => (
//               <li key={i}>
//                 {tx.FromAddress ?? "System"} → {tx.ToAddress}: {tx.Amount}
//               </li>
//             ))}
//           </ul>
//         </div>
//       ))}
//     </div>
//   );
// };

// export default BlockchainChain;


// import React, { useEffect, useState } from "react";
// import { BlockchainService } from "./blockchainService";

// const BlockchainChain = () => {
//   const [chain, setChain] = useState([]);
//   const [loading, setLoading] = useState(true);

// //   useEffect(() => {
// //     const fetchBlockchain = async () => {
// //       try {
// //         const data = await BlockchainService.getBlockchain();
// //         setChain(data);
// //       } catch (err) {
// //         console.error("Error fetching blockchain:", err);
// //       } finally {
// //         setLoading(false);
// //       }
// //     };

// //     fetchBlockchain();
// //   }, []);

// useEffect(() => {
//   const fetchBlockchain = async () => {
//     try {
//       const data = await BlockchainService.getBlockchain();
//       console.log("Blockchain data from API:", data); // check what you get
//       setChain(Array.isArray(data) ? data : data.chain || []);

//     } catch (err) {
//       console.error("Error fetching blockchain:", err);
//       setChain([]); // fallback
//     } finally {
//       setLoading(false);
//     }
//   };

//   fetchBlockchain();
// }, []);

//   if (loading) return <p>Loading blockchain...</p>;
//   if (!chain || chain.length === 0) return <p>No blockchain data found.</p>;

//   return (
//     <div>
//   <h2>Blockchain</h2>
//   {chain.map((block, idx) => (
//     <div key={idx} style={{ border: "1px solid #ccc", margin: "10px", padding: "10px" }}>
//       <p>Index: {block.index}</p>
//       <p>Hash: {block.hash}</p>
//       <p>Previous Hash: {block.previousHash}</p>
//       <p>Miner Address: {block.minerAddress}</p>
//       <p>Timestamp: {block.timestamp}</p>
//       <p>Transactions:</p>
//       <ul>
//         {block.transactions?.map((tx, i) => (
//           <li key={i}>
//             {tx.fromAddress ?? "System"} → {tx.toAddress}: {tx.amount}
//           </li>
//         ))}
//       </ul>
//     </div>
//   ))}
// </div>

//   );
// };

// export default BlockchainChain;


import React, { useEffect, useState } from "react";
import { BlockchainService } from "./blockchainService";

const BlockchainChain = () => {
  const [chain, setChain] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchBlockchain = async () => {
      try {
        const data = await BlockchainService.getBlockchain();
        console.log("Blockchain data from API:", data);
        setChain(Array.isArray(data) ? data : data.chain || []);
      } catch (err) {
        console.error("Error fetching blockchain:", err);
        setChain([]);
      } finally {
        setLoading(false);
      }
    };

    fetchBlockchain();
  }, []);

  if (loading) return <p>Loading blockchain...</p>;
  if (!chain || chain.length === 0) return <p>No blockchain data found.</p>;

  return (
    <div>
      <h2>Blockchain</h2>
      {chain.map((block, idx) => (
        <div key={idx} style={{ border: "1px solid #ccc", margin: "10px", padding: "10px" }}>
          <p>Index: {block.index}</p>
          <p>Hash: {block.hash}</p>
          <p>Previous Hash: {block.previousHash}</p>
          <p>Miner Address: {block.minerAddress}</p>
          <p>Timestamp: {block.timestamp}</p>
          <p>Transactions:</p>
          <ul>
            {block.transactions?.map((tx, i) => (
              <li key={i}>
                {tx.fromAddress ?? "System"} → {tx.toAddress}: {tx.amount}
              </li>
            ))}
          </ul>
        </div>
      ))}
    </div>
  );
};

export default BlockchainChain;
