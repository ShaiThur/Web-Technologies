import React, {useState} from 'react';
import { faStar } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import MyModal from "./MyModal";
import Modal from "react-modal";
import MyModalView from "./MyModalView";

const Post = ({post, nameOfOption}) => {
    const [modalIsOpen, setIsOpen] = useState(false);
    const stars = []
    for (let i = 0; i < post.difficulty; i++)
        stars.push([<FontAwesomeIcon icon={faStar} className="starIcon"/>])

    function showInformation(){
        setIsOpen(true)
    }
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

    // post.date.split('T')[0]

    return (
        <>
            <div className='post' onClick={() => showInformation()}>
                <div className='postContent'>
                    <strong>{post.title}</strong>
                    <div>
                        Срок сдачи: {post.date}
                    </div>

                </div>
                <div className='postHelper'>
                    <div className='difficulty'>
                        {stars}
                    </div>
                    {nameOfOption = "Задачи" ? <></> : <button>Взять</button> }
                </div>
            </div>
            <Modal
                isOpen={modalIsOpen}
                onRequestClose={closeModal}
                style={customStyles}
                contentLabel="Example Modal"
                ariaHideApp={false}
            >
                <MyModalView title={post.title} description={post.description} date={post.date}/>
            </Modal>
        </>
    );
};

export default Post;