import React, { useState } from 'react';
import Modal from 'react-modal';
import EditComponent from '../Employee/EditComponent/EditComponent.js';
import CreateComponent from '../Employee/CreateComponent/CreateComponent.js';

Modal.setAppElement('#root');

function ModalComponent({type, selectedItem, disabled, setError, fetchData, employee}) {
  const [modalIsOpen, setModalIsOpen] = useState(false);

  const openModal = () => setModalIsOpen(true);
  const closeModal = (fetch = false) => {
    setModalIsOpen(false);
    if (fetch){
      fetchData();
    }
  } 

  const style = {
    content: {
      top: '50%',
      left: '50%',
      right: 'auto',
      bottom: 'auto',
      marginRight: '-50%',
      transform: 'translate(-50%, -80%)',
    },
  };

  return (
    <div>
      <button 
        disabled={disabled && selectedItem.length !== 1}
        onClick={openModal}>{type}</button>
      <Modal
        isOpen={modalIsOpen}
        onRequestClose={closeModal}
        contentLabel="Example Modal"
        style={style}
        shouldCloseOnOverlayClick={false}
      >
        {
          type === 'Edit' ? <EditComponent
            employeeId={selectedItem[0]}
            employee={employee}
            setError={setError}
            closeModal={closeModal}
          /> :
          <CreateComponent
            setError={setError}
            closeModal={closeModal}
          />
        }
      </Modal>
    </div>
  );
}

export default ModalComponent;