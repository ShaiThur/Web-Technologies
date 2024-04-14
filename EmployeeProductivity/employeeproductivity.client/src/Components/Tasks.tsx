import React, {useRef, useState} from 'react';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import PostList from "./PostList";
import Modal from 'react-modal';
import MyModal from './MyModal';

const Tasks = (nameOfOption) => {
    const [newPosts, setNewPosts] = useState([])
    const [modalIsOpen, setIsOpen] = useState(false);
    const title = useRef(null)
    const date = useRef(null)
    const difficult = useRef(null)

    const customStyles = {
        content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            bottom: 'auto',
            marginRight: '-50%',
            transform: 'translate(-50%, -50%)',
        },
    };

    function openModal() {
        setIsOpen(true);
      }
    
      function closeModal() {
        setIsOpen(false);
      }

    return (
        <>
            <div className="plusTask" onClick={() => openModal()}>
                <FontAwesomeIcon icon={faPlus} />
            </div>
            <Modal
            isOpen={modalIsOpen}
            onRequestClose={closeModal}
            style={customStyles}
            contentLabel="Example Modal"
            ariaHideApp={false}
            >
                <MyModal setNewPost={setNewPosts} posts={newPosts}/>
            </Modal>
            <PostList posts={newPosts} nameOfOption={"Задачи"}/>
        </>
    );
};

export default Tasks;