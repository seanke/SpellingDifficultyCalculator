import { useState } from 'react'
import { Container, Typography, TextField, Button, Box } from '@mui/material'
import SpellcheckIcon from '@mui/icons-material/Spellcheck'

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
    <Container maxWidth="sm" sx={{ mt: 4, textAlign: 'center' }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Spelling Difficulty Calculator
      </Typography>
      <Box
        component="form"
        onSubmit={handleSubmit}
        sx={{ display: 'flex', gap: 2, justifyContent: 'center', mt: 2 }}
      >
        <TextField
          label="Enter a word"
          value={word}
          onChange={(e) => setWord(e.target.value)}
        />
        <Button variant="contained" type="submit" endIcon={<SpellcheckIcon />}>
          Calculate
        </Button>
      </Box>
      {score !== null && (
        <Typography variant="h6" sx={{ mt: 3 }}>
          Difficulty score: {score}
        </Typography>
      )}
    </Container>
  )
}

export default App
