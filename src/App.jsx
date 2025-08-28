import { useState } from 'react'
import './App.css'

function App() {
  const [word, setWord] = useState('')
  const [score, setScore] = useState(null)

  function calculateScore(w) {
    const lengthScore = w.length
    const vowelScore = (w.match(/[aeiou]/gi) || []).length
    return lengthScore + vowelScore
  }

  function handleSubmit(e) {
    e.preventDefault()
    setScore(calculateScore(word))
  }

  return (
    <>
      <h1>Spelling Difficulty Calculator</h1>
      <form onSubmit={handleSubmit}>
        <input
          value={word}
          onChange={(e) => setWord(e.target.value)}
          placeholder="Enter a word"
        />
        <button type="submit">Calculate</button>
      </form>
      {score !== null && <p>Difficulty score: {score}</p>}
    </>
  )
}

export default App
