/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,ts}",
    './pages/**/*.{html,js}',
    './components/**/*.{html,js}',
  ],
  theme: {
    extend: {
      spacing: {
        84: '21rem',
        100: '33.5rem',
        120: '36rem'

      },
      fontFamily: {
        style: ['Montserrat !important']
      }
    },

  },
  plugins: [],
}


