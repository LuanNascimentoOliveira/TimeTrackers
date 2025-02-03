// eslint-disable-next-line no-undef
const withMT = require("@material-tailwind/react/utils/withMT");

/** @type {import('tailwindcss').Config} */

export default withMT({
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
    "./node_modules/@material-tailwind/react/components/**/*.js",
    "./node_modules/@material-tailwind/react/utilities/**/*.js",
  ],
  theme: {
    screens: {
      sm: '640px',
      md: '768px',
      lg: '1024px',
      xl: '1280px',
    },
    extend: {
      fontFamily: {
        baloo: ['Baloo 2'],
      },

      transitionTimingFunction: {
        'fade-down': 'cubic-bezier(0.33, 1, 0.68, 1)'
      },
    },
  },
  plugins: [],
});
