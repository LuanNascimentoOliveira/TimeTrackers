import { useEffect, useState } from 'react'

function PopUp(isActive) {

  const [showBackground, setShowBackground] = useState(false); // controla o fundo
  const [showPopup, setShowPopup] = useState(false); // controla o popup

  useEffect(() => {
    if (isActive) {
      setShowBackground(true); // ativa o fundo imediatamente
      setTimeout(() => {
        setShowPopup(true); // exibe o popup com atraso
      }, 500); // atraso de 500ms
    } else {
      setShowPopup(false); // oculta o popup
      setTimeout(() => {
        setShowBackground(false); // desativa o fundo com atraso
      }, 500); // corresponde ao tempo da transição
    }
  }, [isActive]);

  // Para esconder automaticamente o popup após 4 segundos
  useEffect(() => {
    if (showPopup) {
      const timer = setTimeout(() => {
        setShowPopup(false);
        setTimeout(() => {
          setShowBackground(false);
        }, 500);
      }, 4000); // esconde o popup após 4 segundos
      return () => clearTimeout(timer); // limpa o timeout ao desmontar
    }
  }, [showPopup]);

  return (
    <>
      {showBackground && (
        <div className='flex justify-center fixed top-0 left-0 w-full h-full z-[9999] bg-blue-gray-700 bg-opacity-10'>
          <div
            className={`gap-2 flex flex-col justify-center items-center bg-white  w-[312px] h-[232px] sm:w-[760px] sm:h-[258px] rounded-2xl shadow-2xl ${showPopup
              ? 'translate-y-52 transition duration-[0.6s] ease-[cubic-bezier(0.33, 1, 0.68, 1)] opacity-100'
              : '-translate-y-52 transition duration-[0.6s] ease-[cubic-bezier(0.33, 1, 0.68, 1)] opacity-0'
              }`}
          >
            {isActive.isActive === 200 ?
              (<>
                <span className='font-extrabold text-5xl'>🎉 Success!</span>
                <span className='font-normal'>You’ve clocked in like a boss!</span>
              </>) : (
                <>
                  <span className='font-extrabold text-3xl'>Oops!</span>
                  <span className='font-extrabold text-3xl'>Registration</span>
                  <span className='font-extrabold text-3xl'>Already Exists!</span>
                  <span className='font-normal text-base'>You&apos;ve already registered.</span>
                  <span className='font-normal text-base'>No need to do it again 😄</span>
                </>
              )}
          </div>
        </div>
      )}
    </>
  );
};

export default PopUp;
