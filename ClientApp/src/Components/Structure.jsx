import React, { useEffect, useState } from "react";

const BlockchainChain = () => {
  const [chain, setChain] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetch("/api/blockchain/chain")
      .then((res) => {
        if (!res.ok) throw new Error("Failed to fetch blockchain");
        return res.json();
      })
      .then((data) => {
        setChain(data);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching blockchain:", err);
        setLoading(false);
      });
  }, []);

  if (loading) return <p>Loading blockchain...</p>;
  if (!chain || chain.length === 0) return <p>No blockchain data found.</p>;

  return (
    <div>
      <h2>Blockchain</h2>
      {chain.map((block, index) => (
        <div key={index} style={{ border: "1px solid #ccc", margin: "10px", padding: "10px" }}>
          <p><strong>Index:</strong> {block.Index}</p>
          <p><strong>Timestamp:</strong> {block.Timestamp}</p>
          <p><strong>Previous Hash:</strong> {block.PreviousHash}</p>
          <p><strong>Hash:</strong> {block.Hash}</p>
          <p><strong>Transactions:</strong></p>
          <ul>
            {block.Transactions.map((tx, i) => (
              <li key={i}>
                {tx.FromAddress ?? "System"} → {tx.ToAddress}: {tx.Amount}
              </li>
            ))}
          </ul>
        </div>
      ))}
    </div>
  );
};

export default BlockchainChain;
