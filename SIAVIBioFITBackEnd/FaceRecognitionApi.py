import face_recognition
import sys
import json

reference_path = "reference.jpg"
captured_path = sys.argv[1]

ref_img = face_recognition.load_image_file(reference_path)
ref_enc = face_recognition.face_encodings(ref_img)[0]

test_img = face_recognition.load_image_file(captured_path)
test_enc = face_recognition.face_encodings(test_img)[0]

match = face_recognition.compare_faces([ref_enc], test_enc)[0]

print(json.dumps({
    "match": match,
    "email": "test@example.com" if match else None
}))
